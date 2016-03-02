var gulp = require('gulp');
var paths = require('../paths');
var browserSync = require('browser-sync');

// Writes changes to files to console
function reportChange(event) {
    console.log('File ' + event.path + ' was ' + event.type + ', running tasks...');
}

// Watches changes to JS, HTML and CSS files and call the reportChange method
gulp.task('watch', ['serve'], function() {
  gulp.watch(paths.js, ['build-system', browserSync.reload]).on('change', reportChange);
  gulp.watch(paths.html, ['build-html', browserSync.reload]).on('change', reportChange);
  gulp.watch(paths.scss, ['build-scss', browserSync.reload]).on('change', reportChange);
});
