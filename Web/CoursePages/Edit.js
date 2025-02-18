function sltPrerequisite_selectedIndexChanged(sender, args) {
    var grid = $find("grdPrerequisites");
    var tempEntity = grid.get_tempEntity();
    if (tempEntity != null) {
        Sys.Observer.setValue(tempEntity, "PrerequisiteTitle", sender.getSelectedDataProperty("Title"));
    }
}

function sltPrerequisite_itemsRequesting(sender, args) {
    var grid = $find("grdPrerequisites");
    var list = grid.get_dataSourceObject().get_entityList();
    var ids = [];
    var editIndex = grid.get_editIndex();
    for (var i = 0; i < list.length; i++) {
        if (i != editIndex) {
            ids.push(list[i].PrerequisiteRef);
        }
    }
    args.get_context()["IgnoredIDs"] = ids;
}