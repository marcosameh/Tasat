function subscribToMailChimp(event) {
  event.preventDefault();

  var emailToSubscribe = $("#email-to-subscribe").val();

  if (!emailToSubscribe) {
    alert("Email field is required");

    return;
  }

  $.ajax({
    url: "/api/mailChimp/subscribe/" + emailToSubscribe,
    type: "GET",
    success: function (response) {
      alert("Successfully Subscribed");
    },
    error: function (response) {
      alert(response.responseText);
      $.unblockUI();
    },
    failure: function (response) {
      alert(response.responseText);
    },
  });
}
