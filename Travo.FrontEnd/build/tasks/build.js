var gulp = require('gulp');
var runSequence = require('run-sequence');
var changed = require('gulp-changed');
var plumber = require('gulp-plumber');
var sourcemaps = require('gulp-sourcemaps');
var sass = require('gulp-sass');
var browserSync = require('browser-sync');
var ts = require('gulp-typescript');
var flatten = require('gulp-flatten');

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
        .pipe(flatten())
        .pipe(gulp.dest(paths.output));
});

// Copies changed HTML files to the output directory
gulp.task('build-html', function () {
    return gulp.src(paths.html)
        .pipe(changed(paths.output, { extension: '.html' }))
        .pipe(flatten())
        .pipe(gulp.dest(paths.output));
});

// Copies images to dist directory
gulp.task('copy-images', function () {
    return gulp.src(paths.img)
        .pipe(changed(paths.output))
        .pipe(flatten())
        .pipe(gulp.dest(paths.output));
});

// Compiles SCSS files and copies them to output directory
gulp.task('build-scss', function () {
    return gulp.src(paths.scss)
        .pipe(plumber())
        .pipe(changed(paths.output, { extension: '.css' }))
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(sass.sync({ outputStyle: 'compressed' }))
        .pipe(sourcemaps.write({ includeContent: true }))
        .pipe(flatten())
        .pipe(gulp.dest(paths.output))
        .pipe(browserSync.stream({match: '**/*.css'}));
});

// Calls the clean task and then runs builds in parallel
gulp.task('build', function (callback) {
    return runSequence(
        'clean',
        ['build-system', 'copy-images', 'build-html', 'build-scss'],
        callback
    );
});
