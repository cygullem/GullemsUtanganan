// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Function to calculate age based on the selected birthday

function calculateAge() {
    var today = new Date();
    var birthDate = new Date(document.getElementById("Birthday").value);
    var age = today.getFullYear() - birthDate.getFullYear();
    
    if (today.getMonth() < birthDate.getMonth() || 
        (today.getMonth() === birthDate.getMonth() && today.getDate() < birthDate.getDate())) {
        age--;
    }
    
    document.getElementById("Age").value = age;
}

document.getElementById("Birthday").addEventListener("change", calculateAge);
