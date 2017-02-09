$('.full-category').on('click', function (e) {


    window.location.href = "Home/RecepiesView" + '?type='+e.currentTarget.id;

});

