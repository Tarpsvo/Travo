var path = require('path');

module.exports = {
    ts:'src/**/*.ts',
    html: 'src/**/*.html',
    scss: 'src/**/*.scss',
    img: ['src/**/*.png'],
    lib: 'src/lib/**/*.*',
    output: 'dist/',
    dtsSrc: [
        './typings/browser/**/*.d.ts',
        './jspm_packages/**/*.d.ts'
    ]
};
