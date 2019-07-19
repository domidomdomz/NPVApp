Vue.directive('focus', {
    inserted: function (el) {
        el.focus();
    }
});

//////////////////// sizes
Vue.directive('width', function (el, binding) {
    el.style.width = binding.value + 'px';
});
Vue.directive('width-inherit', function (el) {
    el.style.width = "inherit";
});
Vue.directive('width-pct', function (el, binding) {
    el.style.width = binding.value + '%';
});
Vue.directive('height', function (el, binding) {
    el.style.height = binding.value + 'px';
});
Vue.directive('height-inherit', function (el) {
    el.style.height = "inherit";
});
Vue.directive('height-pct', function (el, binding) {
    el.style.height = binding.value + '%';
});
Vue.directive('min-height', function (el, binding) {
    el.style.minHeight = binding.value + 'px';
});
Vue.directive('max-height', function (el, binding) {
    el.style.maxHeight = binding.value + 'px';
});
Vue.directive('max-height-pct', function (el, binding) {
    el.style.maxHeight = binding.value + '%';
});
Vue.directive('min-width', function (el, binding) {
    el.style.minWidth = binding.value + 'px';
});
Vue.directive('max-width', function (el, binding) {
    el.style.maxWidth = binding.value + 'px';
});
Vue.directive('max-width-pct', function (el, binding) {
    el.style.maxWidth = binding.value + '%';
});

//////////////////// padding
Vue.directive('pad', function (el, binding) {
    el.style.padding = binding.value + 'px';
});
Vue.directive('pad-top', function (el, binding) {
    el.style.paddingTop = binding.value + 'px';
});
Vue.directive('pad-bottom', function (el, binding) {
    el.style.paddingBottom = binding.value + 'px';
});
Vue.directive('pad-left', function (el, binding) {
    el.style.paddingLeft = binding.value + 'px';
});
Vue.directive('pad-right', function (el, binding) {
    el.style.paddingRight = binding.value + 'px';
});