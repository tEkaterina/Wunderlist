var addEvent = function (elem, type, fn) {
    if (elem.addEventListener) elem.addEventListener(type, fn, false);
    else if (elem.attachEvent) elem.attachEvent('on' + type, fn);
},
        textField = document.getElementById('inputTask'),
        placeholder = 'Добавить задачу...';

addEvent(textField, 'focus', function () {
    if (this.value === placeholder) this.value = '';
});
addEvent(textField, 'blur', function () {
    if (this.value === '') this.value = placeholder;
});