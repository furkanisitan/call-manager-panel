const myv = {};

$(function () {
    $('.phone-number-mask').mask('(000) 000 0000', { placeholder: "(###) ### ####" });

    myv.locale = window.navigator.userLanguage || window.navigator.language;
    moment.locale(myv.locale);
    const localeData = moment.localeData();
    myv.dateTimeFormat = localeData.longDateFormat('l') + ' ' + localeData.longDateFormat('lt');
    myv.dateFormat = localeData.longDateFormat('l');
});

$.fn.datetimepicker.Constructor.Default = $.extend({}, $.fn.datetimepicker.Constructor.Default, { icons: { time: 'far fa-clock', date: 'far fa-calendar', up: 'fas fa-arrow-up', down: 'fas fa-arrow-down', previous: 'fas fa-chevron-left', next: 'fas fa-chevron-right', today: 'far fa-calendar-check-o', clear: 'far fa-trash', close: 'far fa-times' } });

$.fn.serializeObject = function () {
    const o = {};
    const a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

const responseTypes = { JSON: 1, HTML: 2 }
async function postData({ url = '', data = {}, responseType = responseTypes.JSON, addValidateToken = false } = {}) {

    const headers = { 'Content-Type': 'application/json' };

    if (addValidateToken)
        headers['__RequestVerificationToken'] = $('input[name="__RequestVerificationToken"]').val();

    const response = await fetch(url, {
        method: 'POST',
        cache: 'no-cache',
        headers: headers,
        referrerPolicy: 'no-referrer',
        body: JSON.stringify(data)
    });
    if (responseType === responseTypes.JSON)
        return response.json();
    else if (responseType === responseTypes.HTML)
        return response.text();
    return response;
}
