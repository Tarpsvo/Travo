module.exports = function(grunt) {
    require('load-grunt-tasks')(grunt);

    grunt.initConfig({
        sass: {
            options: {},
            dev: {
                options: {
                    style: 'expanded'
                },
                files: {
                    'css/main.css': 'css/scss/main.scss'
                }
            }
        },

        uglify: {
            options: {},
            dev: {
                files: {}
            }
        },

        watch: {
            css: {
                files: ['css/scss/main.scss'],
                tasks: ['sass:dev']
            }
        }
    });

    grunt.registerTask('default', ['sass', 'uglify', 'watch']);
};
