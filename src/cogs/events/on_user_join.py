from nextcord import Member
from nextcord.ext import commands

from config import BOT, WELCOME_CHANNEL, ROLE_MEMBER, SERVER_ID


class OnUserJoinCog(commands.Cog):
    """Message responce commands"""

    @BOT.event
    async def on_member_join(member: Member) -> None:

        channel = BOT.get_channel(WELCOME_CHANNEL)
        await channel.send(
            f"Hello <@{member.id}>, my name is Farin, your local sociopath and host in this server.\n"
            + "If you need anything, or if you've seen Alfonzo recently, let me know!\n_~Farin_"
        )

        await member.add_roles(BOT.get_guild(SERVER_ID).get_role(ROLE_MEMBER))


def setup(bot: commands.Bot):
    bot.add_cog(OnUserJoinCog(bot))
