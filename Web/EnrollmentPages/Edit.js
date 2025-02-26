var grid;
function pageLoad() {
    grid = window.$find("formView_grdEnrollmentItems");
}

function sltPresentation_selectedIndexChanged(sender, args) {
    var tempEntity = grid.get_tempEntity();
    if (tempEntity != null) {
        Sys.Observer.setValue(tempEntity, "CourseTitleText", sender.getSelectedDataProperty("CourseTitle"));
    }
}

function sltPresentation_itemsRequesting(sender, args) {
    const sltStudent = $find("formView_sltStudent");
    if (sltStudent.get_selectedID() == null) {
        throw Error.create("ابتدا دانشجو را انتخاب کنید");
        args.get_context()["StudentNotSelected"] = true;
        return;
    }

    var list = grid.get_dataSourceObject().get_entityList();
    var ids = [];
    var editIndex = grid.get_editIndex();
    for (var i = 0; i < list.length; i++) {
        if (i != editIndex) {
            ids.push(list[i].PresentationRef);
        }
    }
    args.get_context()["IgnoredIDs"] = ids;
    args.get_context()["StudentRef"] = sltStudent.get_selectedID();
}

function sltStudent_selectedIndexChanged(sender, args) {
    var sltPresentation = grid.findEditor("sltPresentation");
    sltPresentation.clearSelection();
    sltPresentation.clearItems();
    sltPresentation.clearCache();
}

function ds_insertedEntity(sender, args) {
    $find("formView_sltStudent").disable();
}

function ds_removedEntity(sender, args) {
    if (sender.get_entityList().length == 0) {
        $find("formView_sltStudent").enable();
    }
}