var gulp = require('gulp');
var runSequence = require('run-sequence');
var changed = require('gulp-changed');
var plumber = require('gulp-plumber');
var to5 = require('gulp-babel');
var sourcemaps = require('gulp-sourcemaps');
var sass = require('gulp-sass');
var browserSync = require('browser-sync');

var paths = require('../paths');
var compilerOptions = require('../babel-options');
var assign = Object.assign || require('object.assign');

// Transpiles changed ES6 files to SystemJS format
// Plumber() prevents the pipe from breaking
gulp.task('build-system', function () {
    return gulp.src(paths.js)
        .pipe(plumber())
        .pipe(changed(paths.output, { extension: '.js' }))
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(to5(assign({}, compilerOptions, { modules: "system" })))
        .pipe(sourcemaps.write({ includeContent: true }))
        .pipe(gulp.dest(paths.output));
});

// Copies changed HTML files to the output directory
gulp.task('build-html', function () {
    return gulp.src(paths.html)
        .pipe(changed(paths.output, { extension: '.html' }))
        .pipe(gulp.dest(paths.output));
});

// Compiles SCSS files and copies them to output directory
gulp.task('build-scss', function () {
    return gulp.src(paths.scss)
        .pipe(changed(paths.output, { extension: '.css' }))
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(sass({ outputStyle: 'compressed' }))
        .pipe(sourcemaps.write({ includeContent: true }))
        .pipe(gulp.dest(paths.output));
});

// Calls the clean task and then runs builds in parallel
gulp.task('build', function (callback) {
    return runSequence(
        'clean',
        ['build-system', 'build-html', 'build-scss'],
        callback
    );
});
