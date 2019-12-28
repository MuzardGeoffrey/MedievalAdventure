using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bdd: MonoBehaviour
{
    private MySqlConnection connection;

    // Constructeur
    public Bdd()
    {
        this.InitConnexion();
    }

    // Méthode pour initialiser la connexion
    private void InitConnexion()
    {
        // Création de la chaîne de connexion
        string connectionString = "SERVER=127.0.0.1; DATABASE=banquedb; UID=root; PASSWORD=";
        this.connection = new MySqlConnection(connectionString);
    }

    // Méthode pour ajouter un contact
    public void AddContact(Toto contact)
    {
        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO contact (id, name, tel) VALUES (@id, @name, @tel)";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@id", contact.Id);
            cmd.Parameters.AddWithValue("@name", contact.Name);
            cmd.Parameters.AddWithValue("@tel", contact.Tel);

            // Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            this.connection.Close();
        }
        catch
        {
            // Gestion des erreurs :
            // Possibilité de créer un Logger pour les exceptions SQL reçus
            // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
        }
    }

    private void Start()
    {
        Toto contact = new Toto();
        contact.Id = 1;
        contact.Name = "Mli";
        contact.Tel = "00 00 00 00 00";

        // Création de l'objet Bdd pour l'intéraction avec la base de donnée MySQL
        Bdd bdd = new Bdd();
        bdd.AddContact(contact);
    }
}
