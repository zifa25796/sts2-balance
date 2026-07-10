

using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace balance.balanceCode.Event;

[HarmonyPatch]
public class TheLanternKeyBalance
{
    [HarmonyPatch]   // ← 加上这一行
    public static class MysteriousKnightNerf
    {
        static IEnumerable<MethodBase> TargetMethods()
        {
            var nested = typeof(MysteriousKnight).GetNestedTypes(AccessTools.all);
            foreach (var t in nested)
            {
                if (typeof(System.Runtime.CompilerServices.IAsyncStateMachine).IsAssignableFrom(t)
                    && t.Name.Contains("AfterAddedToRoom"))
                {
                    var moveNext = AccessTools.Method(t, "MoveNext");
                    if (moveNext != null)
                        yield return moveNext;
                }
            }
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            for (int i = 0; i < codes.Count - 1; i++)
            {
                bool isSix =
                    codes[i].opcode == OpCodes.Ldc_I4_6 ||
                    (codes[i].opcode == OpCodes.Ldc_I4 && codes[i].operand is int iv && iv == 6) ||
                    (codes[i].opcode == OpCodes.Ldc_I4_S && codes[i].operand is sbyte sv && sv == 6);

                if (!isSix) continue;

                if (codes[i + 1].opcode == OpCodes.Newobj &&
                    codes[i + 1].operand is ConstructorInfo ci &&
                    ci.DeclaringType == typeof(decimal))
                {
                    codes[i] = new CodeInstruction(OpCodes.Ldc_I4_4); // 6 -> 4
                }
            }

            return codes;
        }
    }
}