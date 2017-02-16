$('.full-category').on('click', function (e) {


    window.location.href = "Home/RecepiesView" + '?type=' + e.currentTarget.id;
   // window.location = '@Url.Action("RecepiesView", "Home",new { type = e.currentTarget.id })?';


});

