var grid;
function pageLoad() {
    grid = window.$find("formView_grdTimeSlots");
}

function lkpDay_clientSelectedCodeChanged(sender, args) {
    setLookUpValueToEntity(sender, "DayText");
}

function setLookUpValueToEntity(lookUp, entityPropertyName) {
    var currentEntity;
    if (lookUp.get_selectedCode() != null) {
        currentEntity = grid.get_tempEntity();
        window.Sys.Observer.setValue(currentEntity, entityPropertyName, lookUp.get_selectedValue());
    }
    else if (lookUp.get_selectedCode() == null) {
        currentEntity = grid.get_tempEntity();
        window.Sys.Observer.setValue(currentEntity, entityPropertyName, "");
    }
}