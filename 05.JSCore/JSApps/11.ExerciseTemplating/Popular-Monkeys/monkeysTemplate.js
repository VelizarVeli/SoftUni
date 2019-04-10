$(() => {
  loadMonkeys();

  async function loadMonkeys() {
    let allMonkeysHtml = await $.ajax({
      url: "./allMonkeys.html"
    });
    let monkeyHtml = await $.ajax({
      url: "./monkey.html"
    });
    let allMonkeysTemplate = Handlebars.compile(allMonkeysHtml);
    let monkeyTemplate = Handlebars.compile(monkeyHtml);
    let context = {
      monkeys
    };
    Handlebars.registerPartial("monkey", monkeyTemplate);
    $("div.monkeys").html(allMonkeysTemplate(context));
  }
});

function showInfo(id){
    $(`#${id}`).toggle();
}