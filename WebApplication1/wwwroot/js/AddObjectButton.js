    alert("script работает");


    document.getElementById('modalbutton').addEventListener('click', function() {
        if (document.getElementById('1').checked) {
            window.location.href = '/residential';
        } else if (document.getElementById('2').checked) {
            window.location.href = '/map';
        } else {
            alert('Пожалуйста, выберите хотя бы один чекбокс.');
        }
    });


