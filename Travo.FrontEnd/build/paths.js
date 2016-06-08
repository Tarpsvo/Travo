var path = require('path');

module.exports = {
    ts:'src/**/*.ts',
    html: 'src/**/*.html',
    scss: ['src/**/travo-app.scss', 'src/**/!(travo-app)*.scss'],
    img: ['src/**/*.png', 'src/**/*.svg'],
    lib: 'src/lib/**/*.*',
    output: 'dist/',
    dtsSrc: [
        './typings/globals/**/*.d.ts',
        './jspm_packages/**/*.d.ts'
    ]
};
