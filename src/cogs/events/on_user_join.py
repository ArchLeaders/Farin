from nextcord import Member
from nextcord.ext import commands
from config import BOT, CHANNEL_WELCOME, ROLE_MEMBER, SERVER_ID, CHANNEL_GENERAL


class OnUserJoinCog(commands.Cog):
    """Message responce commands"""

    def __init__(self, bot: commands.Bot):
        self.bot = bot

    @BOT.event
    async def on_member_join(member: Member) -> None:

        channel = BOT.get_channel(CHANNEL_WELCOME)

        if member.name.lower() == "alfonzo":
            await channel.send(
                f"Ah, <@{member.id}>, we meet at last. Should I kill you here? Or should we head to <#{CHANNEL_GENERAL}> and do this properly?"
            )

        if member.name.lower() == "boyo":
            await channel.send(f"Oh <@{member.id}>, oh boy... what do we have here?")
            return

        if member.name == "Shooting Star ♡•":
            await channel.send(
                f"Ah <@{member.id}>! Welcome fellow associate to my server (Emerald is just an employee). I'm confident we will be the best of collegues with many deeds of arson to come. :malicious_intent:"
            )
            return

        await channel.send(
            f"Hello <@{member.id}>, my name is Farin, your local sociopath and host in this server.\n"
            + "Take a moment to read the <#900439680514920468> and introduce yourself in <#900439925739106304> to prove yourself trustworthy.\n"
            + "If you need anything, or if you've seen Alfonzo recently, let me know!\n\n"
            + "_~Farin_"
        )


def setup(bot: commands.Bot):
    bot.add_cog(OnUserJoinCog(bot))
