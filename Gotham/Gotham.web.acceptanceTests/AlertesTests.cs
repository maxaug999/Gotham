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
         Title = "je veux pouvoir publier une alerte de sinistre",
         AsA = "En tant qu’utilisateur, ",
         IWant = "je veux pouvoir publier une alerte de sinistre",
         SoThat = "Afin d’informer les citoyens d’un danger potentiel")]
    public class AlertesTests : AcceptanceTestsBase
    {
        private string _htmlPageContent;
        private Alerte _alerte;

        [Fact]
        public void afficher_la_liste_de_joueurs()
        {
            this.Given(x => une_alerte())
                .When(x => l_utilisateur_demande_de_voir_la_liste_des_alertesAsync())
                .Then(x => l_information_concernant_les_alerte_s_affiche())
                .BDDfy();
        }

        private void une_alerte()
        {
            //TODO : Mettre l'application en mode Mocks et aller chercher un joueur dans le Mock
            var mockRepo = new MockAlertesRepository();
            _alerte = mockRepo.GetById(1).Result;
        }

        private async Task l_utilisateur_demande_de_voir_la_liste_des_alertesAsync()
        {
            //On invoque le Contrôleur
            var response = await HttpClient.GetAsync("/Alertes");
            response.EnsureSuccessStatusCode();
            //On lit le contenu de la Vue
            _htmlPageContent = await response.Content.ReadAsStringAsync();
        }

        private void l_information_concernant_les_alerte_s_affiche()
        {
            Assert.Contains(_alerte.Secteur, _htmlPageContent);
            Assert.Contains(_alerte.Risque, _htmlPageContent);
            Assert.Contains(_alerte.Nature, _htmlPageContent);
            Assert.Contains(_alerte.Conseil, _htmlPageContent);
            Assert.Contains(_alerte.Ressource, _htmlPageContent);
        }
    }
}
