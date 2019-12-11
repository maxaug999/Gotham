using Gotham.domain;
using Gotham.persistence;
using System;
using System.Net.Http;
using TestStack.BDDfy;
using Xunit;

namespace Gotham.web.acceptanceTests
{
    [Story(
        Title = "je veux faire la gestion des préventions",
        AsA = "En tant qu'utilisateur, ",
        IWant = "je veux faire la gestion des préventions",
        SoThat = "afin de me tenir informer sur les dangers de la ville."
        )]
    public class PreventionsAcceptanceTests
    {
        private string _htmlPageContent;
        private Prevention PreventionList;

        [Fact]
        public void afficher_toutes_les_preventions()
        {
            this.Given(x => afficher_une_prevention())
                .When(x => l_utilisateur_demande_a_voir_toutes_les_preventionAsync())
                .Then(x => la_liste_de_preventions_s_affichent())
                .BDDfy();
        }

        private void afficher_une_prevention()
        {
            var mockRepo = new MockPreventionRepository();
            PreventionList = mockRepo.GetById(1).Result;
        }

        private async System.Threading.Tasks.Task l_utilisateur_demande_a_voir_toutes_les_preventionAsync()
        {
            var response = await HttpClient.GetAsync("/Preventions");
            response.EnsureSuccessStatusCode();
            _htmlPageContent = await response.Content.ReadAsStringAsync();
        }

        private void la_liste_de_preventions_s_affichent()
        {
            Assert.Contains(PreventionList.Titre, _htmlPageContent);
            Assert.Contains(PreventionList.Texte, _htmlPageContent);
            Assert.Contains(PreventionList.Mois, _htmlPageContent);
            Assert.Contains(PreventionList.Publie, _htmlPageContent);
        }
    }
}
