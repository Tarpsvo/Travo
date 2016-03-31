var gulp = require('gulp');
var runSequence = require('run-sequence');
var changed = require('gulp-changed');
var plumber = require('gulp-plumber');
var sourcemaps = require('gulp-sourcemaps');
var sass = require('gulp-sass');
var browserSync = require('browser-sync');
var ts = require('gulp-typescript');
var concat = require('gulp-concat');

var tsProject = ts.createProject('tsconfig.json');
var paths = require('../paths');
var assign = Object.assign || require('object.assign');

// Transpiles changed ES6 files to SystemJS format
// Plumber() prevents the pipe from breaking
var tsCompiler = tsCompiler || null;
gulp.task('build-system', function () {
    return gulp.src(paths.dtsSrc.concat(paths.ts))
        .pipe(plumber())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(ts(tsProject))
        .pipe(sourcemaps.write({ includeContent: false, sourceRoot: '/src' }))
        .pipe(gulp.dest(paths.output));
});

// Copies changed HTML, image and library files to the output directory
gulp.task('copy-html', function () {
    return gulp.src(paths.html)
        .pipe(changed(paths.output, { extension: '.html' }))
        .pipe(gulp.dest(paths.output));
});

// Copies images to dist directory
gulp.task('copy-images', function () {
    return gulp.src(paths.img)
        .pipe(changed(paths.output))
        .pipe(gulp.dest(paths.output));
});

// Copies lib files to dist directory
gulp.task('copy-lib', function () {
    return gulp.src(paths.lib)
        .pipe(changed(paths.output))
        .pipe(gulp.dest(paths.output + 'lib'));
});

// Compiles SCSS files and copies them to output directory
gulp.task('build-scss', function () {
    return gulp.src(paths.scss)
        .pipe(plumber())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(sass.sync({ outputStyle: 'compressed', includePaths: ['./node_modules/compass-mixins/lib'] }))
        .pipe(sourcemaps.write({ includeContent: true }))
        .pipe(concat('travo.min.css'))
        .pipe(gulp.dest(paths.output + '/assets/styles/'))
        .pipe(browserSync.stream({match: '**/*.css'}));
});

// Gathers general build tasks
gulp.task('build-general', ['copy-html', 'copy-images', 'copy-lib']);

// Calls the clean task and then runs builds in parallel
gulp.task('build', function (callback) {
    return runSequence(
        'clean',
        ['build-system', 'build-general', 'build-scss'],
        callback
    );
});
