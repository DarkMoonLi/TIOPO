from random import randint


class Hero(object):
    # constructor
    def __init__(self,
                 health=20,
                 attack=5,
                 luck=2,
                 ranged=3,
                 defence=1,
                 magic=2,
                 name="Hero",
                 level=0,
                 experience=0,
                 equipment=None
                 ):
        if equipment is None:
            equipment = []
        self.__health = health
        self.__attack = attack
        self.__luck = luck
        self.__ranged = ranged
        self.__defence = defence
        self.__magic = magic
        self.__name = name
        self.__level = level
        self.__experience = experience
        self.__equipment = equipment

    # getters
    def get_health(self):
        return self.__health

    def get_attack(self):
        return self.__attack

    def get_luck(self):
        return self.__luck

    def get_ranged(self):
        return self.__ranged

    def get_defence(self):
        return self.__defence

    def get_magic(self):
        return self.__magic

    def get_name(self):
        return self.__name

    def get_level(self):
        return self.__level

    def get_experience(self):
        return self.__experience

    # setters
    def set_health(self, new_health):
        self.__health = new_health

    def set_attack(self, new_attack):
        self.__attack = new_attack

    def set_luck(self, new_luck):
        self.__luck = new_luck

    def set_ranged(self, new_ranged):
        self.__ranged = new_ranged

    def set_defence(self, new_defence):
        self.__defence = new_defence

    def set_magic(self, new_magic):
        self.__magic = new_magic

    def set_name(self, new_name):
        self.__name = new_name

    def set_level(self, new_level):
        self.__level = new_level

    def set_experience(self, new_experience):
        self.__experience = new_experience

    # methods
    def hit(self):
        return randint(self.__attack, self.__attack + 2)

    def eat(self, food):
        if food.type == "regeneration":
            self.__health += food.regeneration
            return self.__health
        elif food.type == "upgrade":
            self.__health *= food.coef
            return self.__health

    def is_died(self):
        if self.__health <= 0:
            self.__experience = 0
            self.__health = 0
            self.__level = 0
            return True
        else:
            return False

    def get_info(self):
        return self

    def equip_item(self, item):
        self.__equipment.append(item.type)
        if item.type == "weapon":
            self.__attack += item.attack
            self.__magic += item.magic
            self.__luck += item.luck
        elif item.type == "armor":
            self.__health += item.health
            self.__defence += item.defence
            self.__luck += item.luck
        elif item.type == "bow":
            self.__ranged += item.ranged
            self.__luck += item.luck
        return self.get_info()

    def unequip_item(self, item):
        if item.type in self.__equipment:
            if item.type == "weapon":
                self.__attack -= item.attack
                self.__magic -= item.magic
                self.__luck -= item.luck
            elif item.type == "armor":
                self.__health -= item.health
                self.__defence -= item.defence
                self.__luck -= item.luck
            elif item.type == "bow":
                self.__ranged -= item.ranged
                self.__luck -= item.luck
            self.__equipment.remove(item.type)
        return self.get_info()
