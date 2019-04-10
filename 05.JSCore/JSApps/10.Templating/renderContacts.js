function showDetails(id){
$(`#${id}`).toggle();
}

$(async () => {
  try {
    const contactListHTML = await $.get("./contact-list.hbs");
    const contactInfoHTML = await $.get("./contact-list.hbs");

    Handlebars.registerPartial("contactInfo", contactInfoHTML);
    const template = Handlebars.compile(contactListHTML);
    const context = {
      contacts
    }

    const renderedHTML = template(context);
    $('body').append(renderedHTML);
  } catch (err) {
    console.log(err);
  }
});
