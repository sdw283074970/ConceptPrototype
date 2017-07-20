# ConceptPrototype

# These three scripts are utilized to realized a new gameplay mechanism based on Intense Project.
# 这三个脚本是用来在Intense项目上实现一种新的游戏机制。
# The Core of this mechanism is a new method of player respawn, implemented by delegation.
# 这个机制的核心是一种新的玩家重生方法，通过委托来实现。
# The player won't respawn on a random place in FPS/TPS multiplayer mode. Now, they respawn and replace their AI teammate.
# 玩家不会重生在一个随机的地方在FPS和TPS的多人游戏模式。现在，他们的重生和取代他们的AI队友。

# ======================================================================================

# The following is the initialization of the hierarchical configuration in a Unity sense.
# 以下是在一个Unity场景中的初始化层次配置。
# Directly Light
# Terrian
# CameraInit(Perfab)
# EnvFx(Perfab)
# PlayerRespawn(Perfab)
# AIRobot(Optional, remove AIBehavior)
