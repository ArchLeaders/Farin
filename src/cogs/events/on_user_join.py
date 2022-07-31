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

        await channel.send(
            f"Hello <@{member.id}>, my name is Farin, your local sociopath and host in this server.\n"
            + "If you need anything, or if you've seen Alfonzo recently, let me know!\n_~Farin_"
        )

        await member.add_roles(BOT.get_guild(SERVER_ID).get_role(ROLE_MEMBER))


def setup(bot: commands.Bot):
    bot.add_cog(OnUserJoinCog(bot))
