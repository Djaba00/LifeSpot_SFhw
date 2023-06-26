function showWelcomeMessage(){
    
    let age = prompt("Как вас зовут?")

    alert(`Добро пожаловать, ${age}! В вашем имени ${age.length} символов`);

    let elements = document.getElementsByTagName('*');

    alert(`Количество элементов на странице:  ${elements.length}`);
}