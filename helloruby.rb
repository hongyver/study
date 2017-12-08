#def tell_the_true
#	true
#end

#puts tell_the_true()

#puts 'Hello, world!'
#properties = ['object  oriented', 'duck', 'productive', 'fun']
#properties.each {|property| puts "Ruby is #{property}."}
#
#puts "----------------------------------------------------------------"
#
#for i in 1..10
#	puts "#{i}hong"
#end
#
#puts "----------------------------------------------------------------"
#
#6.times {
#	puts "hong"
#}
#
#puts "----------------------------------------------------------------"
#
#str = "Hello, Ruby"
#puts str.index('Hello')
#
#puts "----------------------------------------------------------------"
#
#arrs = [1,2,3,4,5] #,"list", "sdfasdf"]
#puts arrs

#puts arrs[1..2]
#puts "(1..4).class = #{(1..4).class}"
#	
#a = []
#
#puts "a.class = #{a.class}"
#
#a[0] = 11
#a[1] = 12
#puts "a = #{a}"
#
#puts a.methods.include?(:[])
#
#names = {
#	1 => '1',
#	2 => '2',
#	'test' => 'test'
#}
#
#puts "map names[2] = #{names[2]}"
#puts "map names['test'] = #{names['test']}"
#
#list = ['first' , 'second', 'third' , 'forth', 'fifth' ]
#list.each {
#	|a| puts "for each #{a}"
#}
#
#puts 4.class 
#puts 4.class.superclass
#puts 4.class.superclass.superclass
#puts 4.class.superclass.superclass.class
#puts 4.class.superclass.superclass.superclass
#puts 4.class.superclass.superclass.superclass.superclass

# 2017.9.1
puts "2017.9.1"

class Person
	attr :name

	def initialize(name)
		@name = name
	end
	
end

test = Person.new('1212')
puts test.name

puts 2 <=> 1

a = [1,2,3,4]
a.each { |a| puts a.class }
puts a.any? {|a| a > 3}
puts a.inject {|sum, a| sum+a}

class Car
	def move
		puts "Car move"		
	end
end

class Bus
	def move
		puts "Bus move"
	end
end

class Flight
	def fly
		puts "Flight fly"
	end
end

def move(name)
	if name.class.to_s == 'Flight'
		name.fly()
	else
		name.move()
	end
end

car = Car.new()
bus = Bus.new()
flight = Flight.new()

move(car)
move(bus)
move(flight)
class String
	def blank?
		self.size == 0
	end
end
["test", "", "person", nil].each do |element| 
	puts element unless element.blank?
end