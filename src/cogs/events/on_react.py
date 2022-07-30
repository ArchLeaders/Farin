from nextcord import Member, Reaction, Message, TextChannel
from nextcord.ext import commands

from config import BOT, HC_ROLEMENUS


class OnReactCog(commands.Cog):
    """Message responce commands"""

    @commands.Cog.listener()
    async def on_raw_reaction_add(self, payload: Reaction) -> None:

        channel: TextChannel = await BOT.fetch_channel(payload.channel_id)
        member: Member = channel.guild.get_member(payload.user_id)
        emoji = payload.emoji

        for message_id, roles in HC_ROLEMENUS.items():
            if message_id == payload.message_id:
                role = channel.guild.get_role(roles[emoji.name])
                if role not in member.roles:
                    await member.add_roles(role)
                    return

    @commands.Cog.listener()
    async def on_raw_reaction_remove(self, payload) -> None:

        channel: TextChannel = await BOT.fetch_channel(payload.channel_id)
        member: Member = channel.guild.get_member(payload.user_id)
        emoji = payload.emoji

        for message_id, roles in HC_ROLEMENUS.items():
            if message_id == payload.message_id:
                role = channel.guild.get_role(roles[emoji.name])
                if role in member.roles:
                    await member.remove_roles(role)
                    return


def setup(bot: commands.Bot):
    bot.add_cog(OnReactCog(bot))
