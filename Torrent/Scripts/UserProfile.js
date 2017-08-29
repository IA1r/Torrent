function UpdateProfile(model) {

    /// <summary>
    /// Updates the profile.
    /// </summary>
    /// <param name="model">The model of user profile.</param>

    $.post("/api/AccountAPI/UpdateProfile", {
        UserID: model.Id(),
        Password: model.Password(),
        Email: model.Email(),
        Image: model.NewImage(),
    }).done(function () {
        location.reload();
    });
}