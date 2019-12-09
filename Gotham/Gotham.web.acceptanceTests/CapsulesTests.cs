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
         Title = "je veux faire la gestion des capsules informatives existantes",
         AsA = "En tant qu’utilisateur, ",
         IWant = "je veux faire la gestion des capsules informatives existantes",
         SoThat = "afin de garder une liste à jour et pertinente")]
    public class CapsulesTests : AcceptanceTestsBase
    {
        private string _htmlPageContent;
        private Capsule _capsule;

        [Fact]
        public void afficher_la_liste_de_joueurs()
        {
            this.Given(x => une_capsule())
                .When(x => l_utilisateur_demande_de_voir_la_liste_des_capsulesAsync())
                .Then(x => l_information_concernant_les_capsules_s_affiche())
                .BDDfy();
        }

        private void une_capsule()
        {
            //TODO : Mettre l'application en mode Mocks et aller chercher un joueur dans le Mock
            var mockRepo = new MockCapsuleRepository();
            _capsule = mockRepo.GetById(1).Result;
        }

        private async Task l_utilisateur_demande_de_voir_la_liste_des_capsulesAsync()
        {
            //On invoque le Contrôleur
            var response = await HttpClient.GetAsync("/Capsules");
            response.EnsureSuccessStatusCode();
            //On lit le contenu de la Vue
            _htmlPageContent = await response.Content.ReadAsStringAsync();
        }

        private void l_information_concernant_les_capsules_s_affiche()
        {
            Assert.Contains(_capsule.Titre, _htmlPageContent);
            Assert.Contains(_capsule.VideoUrl.ToString(), _htmlPageContent);
        }
    }
}