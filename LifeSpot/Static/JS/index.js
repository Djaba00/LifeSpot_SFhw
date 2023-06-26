// функция фильтра контента 
function filterContent(){

    let videos = document.getElementsByClassName('video-container');

    for(i = 0; i <= videos.length; i++)
    {
        // Вытаскиваем текст описания видео, которое необходимо отфильтровать
        let videoText = videos[i].querySelector('.video-title').innerText;

        // Выполняем фильтрацию, сравнивая значения в нижнем регистре
        if(!videoText.toLowerCase().includes(inputParseFunction().toLowerCase())){

        videos[i].style.display = 'none';
        } 
        else {
            videos[i].style.display = 'inline-block';
        }
    }
}

// функция обработки(парсинга) пользовательского ввода 
const inputParseFunction = function(){
    return document.getElementsByTagName('input')[0].value.toLowerCase()
}

// данные о сессии
let session =  new Map();

// функция обработки информации пользовательской сессии
const handleSession = function(){
    //checkAge();

    sessionData();

    sessionLog();

    return session;
}

const checkAge = function(){
    session.set("age", prompt("Пожалуйста, введите ваш возраст?"));
    if(session.get("age") >= 18){
        let startDate = new Date().toLocaleString();
        alert("Приветствуем на LifeSpot! " + '\n' +  "Текущее время: " + startDate );
    }
    else{
        alert("Наши трансляции не предназначены для лиц моложе 18 лет. ВыL будете перенаправлены");
        window.location.href = "http://www.google.com";
    }
}

const sessionData = function(){
    session.set("userAgent", window.navigator.userAgent);
    
    let startDate = new Date().toLocaleString();
    session.set("startDate", startDate);
}

const sessionLog = function logSession(){
    for(let element of session){
        console.log(element);
    }
}

setTimeout(() =>
    alert("Нравится LifeSpot? " + '\n' +  "Подпишитесь на наш Instagram @lifespot999!" ),
10000);