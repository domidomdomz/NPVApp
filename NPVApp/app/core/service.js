var vueSvc = {
    service: function (name, definition) {
        this[name] = new definition();
    }
};
