var gulp = require('gulp');
var browserSync = require('browser-sync');

// Creates BrowserSync dev. server instance at localhost:9000
gulp.task('serve', ['build'], function (done) {
    browserSync({
        server: {
            baseDir: ""
        }
    }, done);
});
