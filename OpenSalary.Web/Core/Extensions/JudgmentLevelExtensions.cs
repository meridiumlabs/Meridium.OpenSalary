using System;
using OpenSalary.Web.Core.Entities;

namespace OpenSalary.Web.Core.Extensions {   
   public static class JudgmentLevelExtensions {
       public static string GetDescription(this JudgmentCategory category, JudgmentLevel level) {
           switch (category) {
               case JudgmentCategory.Kunskap:
                    switch (level) {
                        case JudgmentLevel.Individ:
                            return @"Du har byggt upp grundläggande kunskap och du känner dig bekväm med att utföra enklare återkommande arbetsuppgifter men behöver mycket stöd av kollegor i det dagliga arbetet. Du lägger mycket tid på att försöka lära dig av dina kollegor i teamet så att du kan vidareutveckla din talang och ta dig ann svårare utmaningar. Du känner dig inte trygg i att utföra nya arbetsuppgifter utan att stöd av kollegor i ditt team. Du jobbar på att försöka våga anta nya utmaningar som ligger utanför din bekvämlighetszon.";
                        case JudgmentLevel.Team:
                            return @"Du hanterar rutinärenden snabbt och effektivt. Du känner dig trygg och bekväm och du tar dig ann nya problem utan stöd. Du hittar lösningar på nya problem. Din kunskap är värdefull för ditt team och du sprider din kunskap till dina kollegor i teamet. Teammedlemmar med mindre kunskap vänder sig till dig spontant för att få hjälp.";
                        case JudgmentLevel.Gille:
                            return @"Du har en bred kunskap och din expertis är efterfrågan över teamgränserna. Med din kunskap bidrar du aktivt till att hjälpa andra team att lösa övergripande utmaningar.  Du hittar banbrytande lösningar på behov som får betydelse över teamgränserna. Du är en stor inspirationskälla för andra både i och utanför teamet.";
                        case JudgmentLevel.Företag:
                            return @"Du har varit framstående i din roll en längre tid men har fortsatt fördjupa dig inom dina kompetensområden. Din kompetens är väsentlig för Meridium och efterfrågas på hela Företaget. Du delar med dig av din kunskap både internt på Meridium och externt. Du genererar mest värde för organisationen genom att du lägger ditt huvudfokus på interna frågor på Meridium.";
                        default:
                            throw new ArgumentOutOfRangeException(nameof(level), level, null);
                    }
               case JudgmentCategory.Företagskultur:
                    switch (level) {
                        case JudgmentLevel.Individ:
                            return @"Du arbetar bäst ensam och har ännu inte funnit nyttan med att samarbeta i team. Du har fullt upp med dig själv och väljer att inte lyssna så mycket på vad andra tycker och säger. Du känner ibland att kraven på kvalitet är onödigt höga. Du delar sällan med dig av dina åsikter. Du trivs bäst med fasta arbetsrutiner. Det arbete som du utför linjerar inte med dina övriga intressen utan är ett sätt att finansiera din tillvaro.";
                        case JudgmentLevel.Team:
                            return @"Du är en viktig kugge i ditt team och hjälper till i teamet så fort du ser att det behövs. Du är noggrann och känner ansvar för den kvaliteté som teamet levererar. Du tar självorganisering på största allvar och jobbar aktivt med ständiga förbättringar i teamet. Du ser ofta lösningar på problem och tar gärna på dig arbetet med att genomföra en förbättring i teamet. Du har inga problem att anpassa dig till förändringar i teamet och delar gärna med dig av dina åsikter och kunskap med dina teammedlemmar. Du känner passion för det arbete du utför och med din positiva inställning sprider du med glädje i teamet.";
                        case JudgmentLevel.Gille:
                            return @"Du är en kulturbärare i ditt team och bidrar samtidigt till en positiv stämning över teamgränserna. Du håller alltid vad du lovar oavsett om det gäller ditt team eller något annat team. Du  bryr dig genuint om dina kollegor även utanför ditt team.  Du delar företagets värderingar som rör självorganisering och transparens. Du deltar aktivt i förbättringsarbeten som stäcker sig över teamgränserna och du tar ansvar för att genomföra förändringar som påverkar flera team. Du gör din röst hörd på hela Meridium och du är lyhörd för andras åsikter över teamgränserna. Du är ärlig i din feedback inte bara i ditt team utan även över teamgränserna.";
                        case JudgmentLevel.Företag:
                            return @"Du har en stor passion inte bara för ditt teams arbete utan även för allt det Meridium står för och du bidrar aktivt till samarbetet på hela företaget. Öppenhet och transparens är det mest självklara för dig och du visar det genom att vara en ambasadör och föredöme. Andras framgång är viktigare för dig än din egen och du har stor förståelse för allas värde oavsett roll på företaget.  Dina kollegor kommer till dig för att få vägledning kring Meridiums företagskultur. Du tror så starkt på Meridiums kultur att du gärna missionerar och sprider den utanför företaget.";
                        default:
                            throw new ArgumentOutOfRangeException(nameof(level), level, null);
                    }
               case JudgmentCategory.Coachning:
                    switch (level) {
                        case JudgmentLevel.Individ:
                            return @"Du är just nu i en fas där du inte känner dig som en naturlig ledare eller coach.  Du känner att du behöver lägga full energi på dig själv och din personliga utveckling vilket gör att det saknas energi/kunskap att leda andra. Ett scenario kan också vara att du inte har ambitioner att leda andra och prioriterar därför inte detta i din utveckling och väljer därför att ledas och inspireras av andra.";
                        case JudgmentLevel.Team:
                            return @"Du coachar dagligen andra i teamet kring enklare frågeställningar och dina närmasta kollegor frågar dig ofta om generella tips och råd som rör teamet. Du använder din erfarenhet för att hjälpa andra i teamet.";
                        case JudgmentLevel.Gille:
                            return @"Du ser dig själv som en naturlig ledare med goda ledaregenskaper och tar gärna på dig en ledande roll även utanför teamet. Även andra utanför ditt team ber dig om råd inför beslut som sträcker sig utanför teamgränserna. Du är empatisk och lyhörd. Du får andra på Meridium att växa. Du är uthållig i ditt ledarskap och behandlar alla lika. Du är duktig på att kommunicera.";
                        case JudgmentLevel.Företag:
                            return @"Dina ledaregenskaper inspirerar och motiverar andra och du bidrar till att utveckla det coachande ledarskapet på Meridium.  Du agerar mentor till andra ledare på hela Meridium och coachar dom framgångsrikt.  Du använder din kunskap för att inspirera och missionera även utanför Meridium i sann Teal-anda.  Din entusiasm och energi kring ledarskap smittar av sig på din omgivning. I kundrelationer leder du även kunden till bra beslut. Du praktiserar gärna 'servant leadership' vilket innebär att du inte untnyttjar din ledande position, du sätter andras behov före dina egna och du brinner för att hjälpa andra att utvecklas och prestera.";
                        default:
                            throw new ArgumentOutOfRangeException(nameof(level), level, null);
                    }
               case JudgmentCategory.Engagemang:
                    switch (level) {
                        case JudgmentLevel.Individ:
                            return @"Du är nöjd med din tillvaro på Meridium och engagerar dig i dina egna arbetsuppgifter men av olika anledningar saknar möjlighet att engagera dig i teamets åtaganden som helhet.Ditt största fokus ligger på dina egna åtaganden och att lösa dina uppgifter på ett så bra sätt som möjligt. Det kan också var så att du rent privat inte har möjlighet att engagerad dig så mycket kring jobbet just nu vilket är helt ok.";
                        case JudgmentLevel.Team:
                            return @"Du visar engagemang för att lösa teamets hela åtagande och bidrar till att förbättra ditt teams arbetssätt. Du känner ett ansvar för att utveckla dina egna färdigheter och förbättra din kompetens. Du ställer upp för dina kollegor i teamet när de behöver hjälp.";
                        case JudgmentLevel.Gille:
                            return @"Du är aktiv och visar ett stort engagemang även utanför ditt team. Du har många idéer på förbättringar som även sträcker sig utanför ditt team. Du gillar att engagera dig i frågor som berör flera team eller som berör frågor kopplade mellan olika roller på Meridium.  Du tar en aktiv roll kring större frågor kan komma att påverka ditt team eller din roll.";
                        case JudgmentLevel.Företag:
                            return @"Du engagerar dig på en strategisk nivå kring frågor som rör hela företaget. Du är aktiv och visar ett stort engagemang för Meridium som helhet. Du har många idéer på förbättringar som du dessutom bidrar aktivt till att förverkliga. Du är drivande vid genomförandet av större förändringar som påverkar hela Meridium.  Du har ett stort intresse för den omvärld som Meridium verkar. Meridiums 'Purpose' är ditt kall.";
                        default:
                            throw new ArgumentOutOfRangeException(nameof(level), level, null);
                    }
               case JudgmentCategory.Kundförståelse:
                    switch (level) {
                        case JudgmentLevel.Individ:
                            return @"Du har  en bra och löpande dialog med dina kunder och du hjälper till med det de ber dig om. Då din kunskap kring det faktiska behovet är begränsad har du svårt att vara proaktiv i din dialog med kund.";
                        case JudgmentLevel.Team:
                            return @"Du lägger stort fokus vid att utföra det kunden ber dig på ett professionellt sätt. Du försöker vara delaktig i teamets alla kundrelationer om teamet jobbar mot flera beställare. Du känner dig nyfiken på kundens verksamhet och vill ta ett större ansvar i kundrelationen. Du är proaktiv och föreslår löpande förbättringar.";
                        case JudgmentLevel.Gille:
                            return @"Du visar ett stort engagemang för dina kunders verksamheter. Du är nyfiken på de branscher som kunderna verkar i och vill hitta möjligheter att förändra och förbättra för deras slutanvändare. Du är drivande  i dialogen med kund och försöker vara i kundens 'value zone' så mycket som kunden önskar.";
                        case JudgmentLevel.Företag:
                            return @"Du visar ett stort intresse för kundens bransch och för slutanvändarens behov. Du är kreativ och ser innovativa lösningar på kundens utmaningar. Dina förslag på åtgärder realiseras ofta och de skapar stora värden för kunden eller kundens kund. Du jobbar stategiskt och långsiktigt med dina kunder. Du inspirerar dina kollegor att hitta vägar för att bygga starka kundrelation. Du är en inspirationskälla på Meridium när det gäller att effektivisera vårt arbete så att maximal nytta kan uppnås för kund med minimal arbetsinsats.";
                        default:
                            throw new ArgumentOutOfRangeException(nameof(level), level, null);
                    }
               default:
                   throw new ArgumentOutOfRangeException(nameof(category), category, null);
           }
       }    
    }
}