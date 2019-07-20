var breadcrumbComponent = Vue.component('breadcrumb', function (resolve, reject) {

    function data() {
        return {

        }
    }

    var props = {
        text1: { type: String },
        route1: { type: String },
        text2: { type: String },
        route2: { type: String },
        text3: { type: String },
        route3: { type: String },
        text4: { type: String },
        route4: { type: String },
        text5: { type: String },
        route5: { type: String }
    };

    function created() {
    }

    function mounted() {
    }

    vueSvc.templates.load("shared/breadcrumb.html").done(function (template) {
        resolve({
            name: "breadcrumb",
            data: data,
            props: props,
            template: template,
            methods: {

            },
            created: created,
            mounted: mounted
        })
    });


});