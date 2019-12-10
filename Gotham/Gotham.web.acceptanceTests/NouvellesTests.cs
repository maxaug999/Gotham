using System;
using System.Collections.Generic;
using System.Text;
using TestStack.BDDfy;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Gotham.domain;
using Gotham.persistence;

namespace Gotham.web.acceptanceTests
{
    [Story(
         Title = "Je veux pouvoir publier une nouvelle et l'afficher",
         AsA = "En tant qu’utilisateur, ",
         IWant = "je veux pouvoir publier une nouvelle",
         SoThat = "Afin d’informer les citoyens sur une nouveauté")]
    public class NouvellesTests : AcceptanceTestsBase
    {
        private string _htmlPageContent;
        private Nouvelle _nouvelle;

        [Fact]
        public void afficher_la_liste_de_joueurs()
        {
            this.Given(x => une_alerte())
                .When(x => l_utilisateur_demande_de_voir_la_liste_des_nouvellesAsync())
                .Then(x => l_information_concernant_les_nouvelles_s_affiche())
                .BDDfy();
        }

        private void une_alerte()
        {
            //TODO : Mettre l'application en mode Mocks et aller chercher un joueur dans le Mock
            var mockRepo = new MockNouvellesRepository();
            _nouvelle = mockRepo.GetById(1).Result;
        }

        private async Task l_utilisateur_demande_de_voir_la_liste_des_nouvellesAsync()
        {
            //On invoque le Contrôleur
            var response = await HttpClient.GetAsync("/Nouvelles");
            response.EnsureSuccessStatusCode();
            //On lit le contenu de la Vue
            _htmlPageContent = await response.Content.ReadAsStringAsync();
        }

        private void l_information_concernant_les_nouvelles_s_affiche()
        {
            Assert.Contains(_nouvelle.Titre, _htmlPageContent);
            Assert.Contains(_nouvelle.Texte, _htmlPageContent);
            Assert.Contains(_nouvelle.Lien, _htmlPageContent);
            Assert.Contains(_nouvelle.Status.ToString(), _htmlPageContent);
        }
    }
}