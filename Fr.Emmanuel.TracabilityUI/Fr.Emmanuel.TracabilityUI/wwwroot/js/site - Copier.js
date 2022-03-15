// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$('#btn_add_RetourControleur').on('click', function () {
    var IdControleur = document.getElementById("IdControleur").value;
    var dateRetour = document.getElementById("dateRetour").value;
    var libelleRetour = document.getElementById("libelleRetour").value;
    
    

    $.ajax({
        type: "POST",
        url: "/RetourControleur/RetourControleur/Create/",
        data: 'IdControleur=' + IdControleur + '&dateRetour=' + dateRetour + '&libelleRetour=' + libelleRetour,
        success: function () {
            Swal.fire({
                title: "Ajoutée !",
                text: "Retour ajouté avec succès",
                type: "success"
            }).then(
                //on recharge la page pour afficher les nouveaux résultats
                function () {
                    document.location.reload();
                });
        },
        error: function () {
            Swal.fire(
                "Erreur d'ajout dans la base.",
                "Veuillez vérifier les champs remplis !",
                "error"
            )
        }
    });
});