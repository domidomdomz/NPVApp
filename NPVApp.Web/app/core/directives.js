Vue.directive('focus', {
    inserted: function (el) {
        el.focus();
    }
});

Vue.directive('hand', function (el) {
    el.style.cursor = 'pointer';
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


//////////////////// fonts
Vue.directive('font-pt', function (el, binding) {
    el.style.fontSize = binding.value + 'pt';
});
Vue.directive('font-pct', function (el, binding) {
    el.style.fontSize = binding.value + '%';
});
Vue.directive('font-wt', function (el, binding) {
    el.style.fontWeight = binding.value;
});
Vue.directive('bold', function (el, binding) {
    el.style.fontWeight = 'bold';
});
Vue.directive('line-through', function (el) {
    el.style.textDecoration = 'line-through';
});
Vue.directive('underline', function (el) {
    el.style.textDecoration = 'underline';
});
Vue.directive('italic', function (el) {
    el.style.fontStyle = 'italic';
});


//////////////////// whitespace
Vue.directive('pre-wrap', function (el) {
    el.style.whiteSpace = 'pre-wrap';
});
Vue.directive('no-wrap', function (el) {
    el.style.whiteSpace = 'nowrap';
});
Vue.directive('normal-wrap', function (el) {
    el.style.whiteSpace = 'normal';
});


//////////////////// color
Vue.directive('color', function (el, binding) {
    el.style.color = binding.value;
});
Vue.directive('bg-color', function (el, binding) {
    el.style.backgroundColor = binding.value;
});

//////////////////// text align
Vue.directive('center', function (el) {
    el.style.textAlign = 'center';
});
Vue.directive('left', function (el) {
    el.style.textAlign = 'left';
});
Vue.directive('right', function (el) {
    el.style.textAlign = 'right';
});

//////////////////// vertical align
Vue.directive('top', function (el) {
    el.style.verticalAlign = 'top';
});
Vue.directive('middle', function (el) {
    el.style.verticalAlign = 'middle';
});
Vue.directive('bottom', function (el) {
    el.style.verticalAlign = 'bottom';
});