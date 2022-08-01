from config import BOT, ROLE_ADMIN
from nextcord import Member, Reaction, Message, TextChannel
from nextcord.ext import commands
from utils import has_role, add_responce


class OnReact(commands.Cog):
    """Message responce commands"""

    @commands.Cog.listener()
    async def on_raw_reaction_add(self, payload: Reaction) -> None:

        channel: TextChannel = await BOT.fetch_channel(payload.channel_id)
        message: Message = await channel.fetch_message(payload.message_id)
        member: Member = channel.guild.get_member(payload.user_id)
        emoji = payload.emoji

        if member.id == BOT.user.id:
            return

        if len(message.embeds) >= 1:
            if message.embeds[0].title == "A request from master Benji~":

                if not await has_role(member, [ROLE_ADMIN], message):
                    return

                if emoji.name == "✅":
                    await add_responce(message.embeds[0], message)
                elif emoji.name == "❎":
                    await message.delete()


def setup(bot: commands.Bot):
    bot.add_cog(OnReact(bot))
