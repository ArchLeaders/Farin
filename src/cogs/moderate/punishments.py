import humanfriendly
import datetime

from config import BOT, ROLE_ADMIN, ROLE_MODERATOR
from nextcord import Message, Member
from nextcord.ext import commands
from nextcord.utils import utcnow
from utils import has_role, strike


class Punishments(commands.Cog):
    """Ban, Kick and other server punishment commands"""

    def __init__(self, bot: commands.Bot):
        self.bot = bot
        self.roles = [ROLE_ADMIN, ROLE_MODERATOR]

    def get_user_id(self, user: str) -> int:
        return int(user.replace("<@", "").replace(">", ""))

    @commands.command()
    async def punish(self, ctx: commands.Context, action: str, user: str, *, reason):

        if not await has_role(ctx.author, self.roles, ctx.message):
            return

        user_id = self.get_user_id(user)

        if action == "ban":
            await ctx.guild.ban(
                BOT.get_user(user_id), reason=reason, delete_message_days=7
            )
            await ctx.channel.send(
                f"*<@{user_id}> has been assassinated.*\n\n**Reason:**\n{str(reason)}"
            )
        elif action == "kick":
            await ctx.guild.kick(BOT.get_user(user_id), reason=reason)
            await ctx.channel.send(
                f"*<@{user_id}> has been removed from the premises.*\n\n**Reason:**\n{str(reason)}"
            )
        elif action == "strike":
            await strike(BOT.get_user(user_id), reason=reason)

    @commands.command()
    async def ban(self, ctx: commands.Context, user: str, *, reason: str):
        await self.punish(ctx, "ban", user, reason=reason)

    @commands.command()
    async def kick(self, ctx: commands.Context, user: str, *, reason: str):
        await self.punish(ctx, "kick", user, reason=reason)

    @commands.command()
    async def strike(self, ctx: commands.Context, user: str, *, reason: str):
        await self.punish(ctx, "strike", user, reason=reason)

    @commands.command()
    async def mute(self, ctx: commands.Context, member: Member, time, *, reason=None):

        if not await has_role(ctx.author, [ROLE_ADMIN, ROLE_MODERATOR], ctx.message):
            return

        time = humanfriendly.parse_timespan(time)
        await member.edit(timeout=utcnow() + datetime.timedelta(seconds=time))
        await ctx.channel.send(
            f"*<@{member.id}> has been silenced.*\n\n**Reason:**\n{str(reason)}"
        )

    @commands.command()
    async def unmute(self, ctx: commands.Context, member: Member, *, reason=None):

        if not await has_role(ctx.author, [ROLE_ADMIN, ROLE_MODERATOR], ctx.message):
            return

        await member.edit(timeout=None)
        await ctx.channel.send(
            f"*<@{member.id}> has been revived.*\n\n**Reason:**\n{str(reason)}"
        )


def setup(bot: commands.Bot):
    bot.add_cog(Punishments(bot))
