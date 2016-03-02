var gulp = require('gulp');
var paths = require('../paths');
var del = require('del');
var vinylPaths = require('vinyl-paths');

// Delete all files at output path
gulp.task('clean', function() {
    return gulp.src([paths.output])
        .pipe(vinylPaths(del));
});
