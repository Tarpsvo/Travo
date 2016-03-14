var gulp = require('gulp');
var paths = require('../paths');
var browserSync = require('browser-sync');

// Writes changes to files to console
function reportChange(event) {
    console.log('File ' + event.path + ' was ' + event.type + ', running tasks...');
}

// Fix for hard reloading instead of streaming
gulp.task('build-system-w-reload', ['build-system'], browserSync.reload);
gulp.task('copy-html-w-reload', ['copy-html'], browserSync.reload);
gulp.task('copy-lib-w-reload', ['copy-lib'], browserSync.reload);

// Watches changes to JS, HTML and CSS files and call the reportChange method
gulp.task('watch', ['serve'], function() {
    gulp.watch(paths.ts, ['build-system-w-reload']).on('change', reportChange);
    gulp.watch(paths.html, ['build-html-w-reload']).on('change', reportChange);
    gulp.watch(paths.scss, ['build-scss']).on('change', reportChange);
    gulp.watch(paths.img, ['copy-images']).on('change', reportChange);
    gulp.watch(paths.lib, ['copy-lib']).on('change', reportChange);
});
