/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    function BuildDate() {
        function padDigits(number) { return number < 10 ? "0" + number : number; }
        var now = new Date();
        return "" + now.getFullYear() + "." +
            padDigits(now.getMonth()) + padDigits(now.getDate()) + "." +
            padDigits(now.getHours()) + padDigits(now.getMinutes());
    }

    // minify javascript
    var uglifyConfig = {
        "NPV-lib": {
            options: {
                preserveComments: false,
                mangle: true,
                compress: true,
                sourceMap: false
            },
            files: {
                "dist/npv-lib.min.js": [
                    "node_modules/jquery/dist/jquery.min.js",
                    "node_modules/vue/dist/vue.min.js",
                    "node_modules/vue-router/dist/vue-router.min.js",
                    "node_modules/popper.js/dist/umd/popper.min.js",
                    "node_modules/bootstrap/dist/js/bootstrap.min.js",
                    "node_modules/moment/min/moment.min.js",
                    "node_modules/lodash/lodash.min.js",
                    "node_modules/notifyjs-browser/dist/notify.js",
                    "node_modules/sweetalert/dist/sweetalert.min.js"
                ]
            }
        },
        "NPV-app": {
            options: {
                preserveComments: false,
                mangle: true,
                compress: true,
                sourceMap: false
            },
            files: {
                "dist/npv-app.min.js": [
                    "app/core/service.js",
                    "app/services/svc-base.js",
                    "app/services/*-svc.js",
                    "app/components/**/*.js",
                    "app/core/constants.js",
                    "app/core/common.js",
                    "app/core/routes.js",
                    "app/core/router.js",
                    "app/core/directives.js",
                    "app/core/filters.js",
                    "app/core/app.js"
                ]
            }
        }
    };

    // minify css
    var cssminConfig = {
        "NPV-lib": {
            options: {
                shorthandCompacting: true,
                roundingPrecision: -1,
                keepSpecialComments: 0,
                noAdvanced: false,
                rebase: true
            },
            files: {
                "dist/npv-lib.min.css": [
                    "node_modules/bootstrap/dist/css/bootstrap.min.css",
                    "node_modules/glyphicons-only-bootstrap/css/bootstrap.min.css"
                ]
            }
        },
        "NPV-app": {
            options: {
                shorthandCompacting: true,
                roundingPrecision: -1,
                keepSpecialComments: 0,
                noAdvanced: false,
                rebase: true
            },
            files: {
                "dist/npv-app.min.css": [
                    "styles/npvapp.css"
                ]
            }
        }
    };

    // minify html
    var htmlMinConfig = {
        options: {
            removeComments: true,
            collapseWhitespace: true,
            conservativeCollapse: true,
            caseSensitive: true
        },
        components: {
            files: [{
                cwd: "app",
                expand: true,
                src: ['components/**/*.html'],
                dest: 'dist'
            }]
        },
        index: {
            files: [{
                cwd: "app",
                expand: true,
                src: ['index/*.cshtml'],
                dest: 'dist'
            }]
        },
    }

    var replaceConfig = {
        "components-and-build": {
            options: {
                replacements: [{
                    pattern: /\/app\/components\//g,
                    replacement: "/dist/components/"
                }, {
                    pattern: /BuildDate=/g,
                    replacement: "BuildDate='" + BuildDate() + "';"
                }, {
                    pattern: /&apos;/g,
                    replacement: "\\'"
                }]
            },
            files: [{
                src: "dist/npv-app.min.js",
                dest: "dist/npv-app.min.js",
                overwrite: true
            }]
        },
        "cshtml-build": {
            options: {
                replacements: [{
                    pattern: /BUILD_DATE/g,
                    replacement: BuildDate()
                }]
            },
            files: [{
                src: ['dist/**/*.cshtml'],
                dest: 'dist/',
                overwrite: true
            }]
        }
    }

    // initialize grunt config
    grunt.initConfig({
        uglify: uglifyConfig,
        cssmin: cssminConfig,
        htmlmin: htmlMinConfig,
        "string-replace": replaceConfig
    });

    grunt.registerTask("default", ["htmlmin", "uglify", "cssmin", "string-replace"]);

    grunt.loadNpmTasks("grunt-contrib-cssmin");
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-htmlmin");
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks("grunt-string-replace");
};