var path = require('path');

module.exports = {
    ts: ['src/**/*.ts', 'pages/**/*.ts', 'components/**/*.ts'],
    html: ['src/**/*.html', 'pages/**/*.html', 'components/**/*.html'],
    scss: 'assets/styles/**/*.scss',
    output: 'dist/',
    dtsSrc: [
        './typings/browser/**/*.d.ts',
        './jspm_packages/**/*.d.ts'
    ]
};
