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
         Title = "Je veux pouvoir publier un signalement et l'afficher",
         AsA = "En tant qu’utilisateur, ",
         IWant = "je veux pouvoir publier un signalement",
         SoThat = "Afin d’informer les citoyens sur une nouveauté")]
    public class SignalementsTests : AcceptanceTestsBase
    {
        private string _htmlPageContent;
        private Signalement _signalement;

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
            var mockRepo = new MockSignalementsRepository();
            _signalement = mockRepo.GetById(1).Result;
        }

        private async Task l_utilisateur_demande_de_voir_la_liste_des_nouvellesAsync()
        {
            //On invoque le Contrôleur
            var response = await HttpClient.GetAsync("/Signalements");
            response.EnsureSuccessStatusCode();
            //On lit le contenu de la Vue
            _htmlPageContent = await response.Content.ReadAsStringAsync();
        }

        private void l_information_concernant_les_nouvelles_s_affiche()
        {
            //Assert.Contains(_signalement.Nature, _htmlPageContent);
            //Assert.Contains(_signalement.Secteur, _htmlPageContent);
            //Assert.Contains(_signalement.Heure, _htmlPageContent);
            //Assert.Contains(_signalement.Commentaires, _htmlPageContent);
        }
    }
}