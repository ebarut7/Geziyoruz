let currentIndex = 0;
const slides = document.querySelectorAll('.slide');
const totalSlides = slides.length;

function showSlide(index) {
    slides.forEach((slide) => {
        slide.style.transform = `translateX(-${index * 100}%)`;
    });
    currentIndex = index;
}

function prevSlide() {
    if (currentIndex > 0) {
        showSlide(currentIndex - 1);
    } else {
        showSlide(totalSlides - 1);
    }
}

function nextSlide() {
    if (currentIndex < totalSlides - 1) {
        showSlide(currentIndex + 1);
    } else {
        showSlide(0);
    }
}

setInterval(nextSlide, 5000); // 5 saniyede bir slayt değiştir
