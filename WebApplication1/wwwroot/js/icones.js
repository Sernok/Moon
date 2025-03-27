let selectedValue = this.getAttribute('value'); // Получаем значение
document.getElementById('Construction').value = selectedValue;

let iconElement = document.createElement('i');

if (selectedValue === "Жилые модули") {
    iconElement.classList.add('bi bi-house-door-fill');
}
else if (selectedValue === "Спортивные модули") {
    iconElement.classList.add('bi bi-bicycle');
}

else if (selectedValue === "Административные модули") {
    iconElement.classList.add('bi bi-building');
}
else if (selectedValue === "Медицинские модули") {
    iconElement.classList.add('bi bi-heart-pulse-fill');
}
else if (selectedValue === "Исследовательские модули") {
    iconElement.classList.add('bi bi-binoculars-fill');
}

else if (selectedValue === "Ремонтные модули") {
    iconElement.classList.add('fa-solid fa-screwdriver-wrench');
}
else if (selectedValue === "Космодромы") {
    iconElement.classList.add('fa-solid fa-rocket');
}
else if (selectedValue === "Вышки связи") {
    iconElement.classList.add('fa-solid fa-satellite-dish');
}

else if (selectedValue === "Плантации") {
    iconElement.classList.add('fa-solid fa-spa');
}
else if (selectedValue === "Мусорные полигоны") {
    iconElement.classList.add('fa-solid fa-trash');
}
else if (selectedValue === "Производственные предприятия") {
    iconElement.classList.add('fa-solid fa-industry');
}

else if (selectedValue === "Астрономические площадки") {
    iconElement.classList.add('fa-solid fa-eye');
}
else if (selectedValue === "Солнечные электростанции") {
    iconElement.classList.add('fa-solid fa-solar-panel');
}
else if (selectedValue === "Добывающие шахты") {
    iconElement.classList.add('fa-solid fa-helmet-safety');
}