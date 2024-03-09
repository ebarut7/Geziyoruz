function openTab(tabName) {
    var i, tabContent;

    // Tüm içerikleri gizle
    tabContent = document.getElementsByClassName("content");
    for (i = 0; i < tabContent.length; i++) {
        tabContent[i].style.display = "none";
    }

    // Seçilen sekmenin içeriğini göster
    document.getElementById(tabName).style.display = "block";

    // Aktif sekme stilini güncelle
    var activeTabs = document.querySelectorAll('.sidebar a.active');
    for (i = 0; i < activeTabs.length; i++) {
        activeTabs[i].classList.remove('active');
    }

    var clickedTab = document.querySelector('.sidebar a[href="#' + tabName + '"]');
    clickedTab.classList.add('active');
}
