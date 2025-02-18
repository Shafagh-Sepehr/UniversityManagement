function sltPrerequisite_selectedIndexChanged(sender, args) {
    var grid = $find("grdPrerequisites");
    var tempEntity = grid.get_tempEntity();
    if (tempEntity != null) {
        Sys.Observer.setValue(tempEntity, "PrerequisiteTitle", sender.getSelectedDataProperty("Title"));
    }
}