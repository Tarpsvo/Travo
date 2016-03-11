var gulp = require('gulp');
var browserSync = require('browser-sync');

// Creates BrowserSync dev. server instance at localhost:9000
gulp.task('serve', ['build'], function (done) {
    browserSync({
        proxy: {
            target: 'localhost:80',
            middleware: function (req, res, next) {
                res.setHeader('Access-Control-Allow-Origin', '*');
                next();
            }
        }
    }, done);
});
