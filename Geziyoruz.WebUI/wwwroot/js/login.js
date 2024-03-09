const signInBtn = document.getElementById('signInBtn');
const signUpBtn = document.getElementById('signUpBtn');
const signInForm = document.querySelector('.sign-in-form');
const signUpForm = document.querySelector('.sign-up-form');

signInBtn.addEventListener('click', () => {
    signInForm.classList.add('active');
    signUpForm.classList.remove('active');
});

signUpBtn.addEventListener('click', () => {
    signInForm.classList.remove('active');
    signUpForm.classList.add('active');
});
