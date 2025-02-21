using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write("이름을 입력하세요 : ");
            //string userName = ReadLine();

            //WriteLine($"안녕하세요, {userName}님!");

            //// 문자열을 정수로 변환
            //Write("나이를 입력하세요 : ");
            //string input = ReadLine();
            //int age = int.Parse(input);

            //WriteLine($"내년에는 {age + 1}살이 되겠군요!");

            Write("루인 스킬 피해를 입력해 주세요. : ");
            float ruinSkillDamage = float.Parse(ReadLine());

            Write("카드 게이지 획득량을 입력해 주세요. : ");
            float cardGageGet = float.Parse(ReadLine());

            Write("각성기 피해를 입력해 주세요. : ");
            float UltimateSkillDamage = float.Parse(ReadLine());

            Write("최대 마나를 입력해 주세요. : ");
            int maxMP = int.Parse(ReadLine());

            Write("전투중 마나 회복량을 입력해 주세요. : ");
            int inFightMPHeal = int.Parse(ReadLine());

            Write("비전투 중 마나 회복량을 입력해 주세요. : ");
            int outFightMPHeal = int.Parse(ReadLine());

            Write("이동 속도를 입력해 주세요. : ");
            float speed = float.Parse(ReadLine());

            Write("탈 것 속도를 입력해 주세요. : ");
            float animalSpeed = float.Parse(ReadLine());

            Write("운반 속도를 입력해 주세요. : ");
            float togetherSpeed = float.Parse(ReadLine());

            Write("스킬 재사용 대기시간 감소를 입력해 주세요. : ");
            float skillReuse = float.Parse(ReadLine());

            Clear();

            WriteLine($"활동");
            WriteLine($"루인 스킬 피해 : {ruinSkillDamage}%");
            WriteLine($"카드 게이지 획득량 : {cardGageGet}%");
            WriteLine($"각성기 피해 : {UltimateSkillDamage}%");
            WriteLine($"최대 마나 : {maxMP}");
            WriteLine($"전투 중 마나 회복량 : {inFightMPHeal}");
            WriteLine($"비전투 중 마나 회복량 : {outFightMPHeal}");
            WriteLine($"이동 속도 : {speed:f1}%");
            WriteLine($"탈 것 속도 : {animalSpeed:F1}%");
            WriteLine($"운반 속도 : {togetherSpeed:f1}%");
            WriteLine($"스킬 재사용 대기시간 감소 : {skillReuse:f1}%");

        }
    }
}
