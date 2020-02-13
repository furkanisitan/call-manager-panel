const title = document.querySelector('.error-title');


//////// Light //////////
document.onmousemove = function(e) {
    const x = e.pageX - window.innerWidth/2;
    const y = e.pageY - window.innerHeight/2;

    title.style.setProperty('--x', x + 'px');
    title.style.setProperty('--y', y + 'px');
}

////////////// Shadow ///////////////////
title.onmousemove = function(e) {
    const x = e.pageX - window.innerWidth/2;
    const y = e.pageY - window.innerHeight/2;

    const rad = Math.atan2(y, x).toFixed(2); 
    const length = Math.round(Math.sqrt((Math.pow(x,2))+(Math.pow(y,2)))/10); 

    const xShadow = Math.round(length * Math.cos(rad));
    const yShadow = Math.round(length * Math.sin(rad));

    title.style.setProperty('--x-shadow', - xShadow + 'px');
    title.style.setProperty('--y-shadow', - yShadow + 'px');

}