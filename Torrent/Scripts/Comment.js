
function EditComment(model) {
    /// <summary>
    /// Updates the message.
    /// </summary>
    /// <param name="model">The model of message.</param>

    $.post("/api/TorrentAPI/EditComment", {
        CommentID: model.CommentID(),
        CommentText: model.CommentText()
    });
}